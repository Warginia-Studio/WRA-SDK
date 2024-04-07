using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class WraGameConsole : PanelBase
    {
        public static List<ICommand> Commands { get; protected set; } = new List<ICommand>()
        {
            new HelpCommand(),
            new LanguageCommand(),
            new ConsoleCommand()
        };
        
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Transform logContainer;
        [SerializeField] private SimpleLog simpleLogPrefab;
        [SerializeField] private CommandInputHelper commandInputHelper;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private TMP_Dropdown tagSelector;
    
        private List<string> executedCommands = new List<string>();

        private TweenerCore<float, float, FloatOptions> lastTween;
        private int currentTagIndex = 0;

        private string lastText = "";

        private void Awake()
        {
            RegisterEvenets();
        }

        private void Start()
        {
            OnTagAdded("");
        }

        private void OnDestroy()
        {
            UnRegisterEvents();
        }

        // private void Update()
        // {
        //     if (string.IsNullOrEmpty(inputField.text))
        //     {
        //         commandInputHelper.DestroyCommands();
        //         return;
        //     }
        //
        //     if (inputField.text == lastText)
        //         return;
        //     
        //     OnCommandWrite(inputField.text);
        //     lastText = inputField.text;
        // }

        public override void OnOpen()
        {
            base.OnOpen();
            var data =GetDataAsType<PanelDataBase>();
            if(data.StartAsHide)
                HideThisPanel();
            else
            {
                ShowThisPanel();
            }
        }

        public override void OnClose()
        {
            PanelManager.Instance.ClosePanel<WraGameConsole>(null);
        }

        public override void OnShow()
        {
            base.OnShow();
            transform.SetAsLastSibling();
            // canvasGroup.alpha = 1;
            // transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        public override void OnHide()
        {
            base.OnHide();
            // canvasGroup.alpha = 0;
        }

        // public void OnCommandWrite(string command)
        // {
        //     commandInputHelper.ShowCommands(command + "test", command + "test2", command + "test3");
        // }

        public void ExecuteCommand(string command)
        {
            
            inputField.text = "";
            if (string.IsNullOrEmpty(command))
                return;
            executedCommands.Add(command);
            var splited = command.Split(" ");
            WraDiagnostics.Log(command, "CMD");
            if (splited.Length == 0)
            {
                WraDiagnostics.LogError("Command is empty");
                return;
            }
            var cmd = Commands.Find(ctg => ctg.Name == splited[0]);
            if (cmd == null)
            {
                WraDiagnostics.LogError($"Command '{splited[0]}' not found");
                return;
            }
            cmd.Execute(splited);
        }
    
        public void ClearLogs()
        {
            ClearView();
            WraDiagnostics.ClearLogs();
        }

        public void ClearView()
        {
            foreach (Transform VARIABLE in logContainer.transform)
            {
                Destroy(VARIABLE.gameObject);
            }
        }

        private void RegisterEvenets()
        {
            tagSelector.onValueChanged.AddListener(OnTagChanged);
            // inputField.onValueChanged.AddListener(OnCommandWrite);
            inputField.onSubmit.AddListener(ExecuteCommand);
            // inputField.onSelect.AddListener(OnSelectedInputField);
            // inputField.onDeselect.AddListener(OnDeselectInputField);
            WraDiagnostics.OnLog.AddListener(OnLog);
            WraDiagnostics.OnTagAdded.AddListener(OnTagAdded);
        }
    
        private void UnRegisterEvents()
        {
            tagSelector.onValueChanged.RemoveListener(OnTagChanged);
            // inputField.onValueChanged.RemoveListener(OnCommandWrite);
            inputField.onSubmit.RemoveListener(ExecuteCommand);
            // inputField.onSelect.RemoveListener(OnSelectedInputField);
            // inputField.onDeselect.RemoveListener(OnDeselectInputField);
            WraDiagnostics.OnLog.RemoveListener(OnLog);
            WraDiagnostics.OnTagAdded.RemoveListener(OnTagAdded);
        }

        private void OnLog(WraLogData arg0)
        {
            if (currentTagIndex != 0 && arg0.LogTag != WraDiagnostics.GetTags()[currentTagIndex])
                return;
        
            var log = Instantiate(simpleLogPrefab, logContainer);
            log.Bind(arg0.Message, arg0.LogColor);
            lastTween = DOTween.To(() => scrollRect.verticalNormalizedPosition, x => scrollRect.verticalNormalizedPosition = x, 0,
                0.5f);
        }

        // private void OnSelectedInputField(string arg0)
        // {
        //     commandInputHelper.DestroyCommands();
        //     WraDiagnostics.LogWarning("Selected cmd input field but not implemented yet.");
        // }
    
        // private void OnDeselectInputField(string arg0)
        // {
        //     commandInputHelper.DestroyCommands();
        //     WraDiagnostics.LogWarning("Deselected cmd input field but not implemented yet.");
        // }

        private void OnTagAdded(string str)
        {
            tagSelector.ClearOptions();
            tagSelector.AddOptions(WraDiagnostics.GetTags());
            tagSelector.value = 0;
        }

        private void OnTagChanged(int arg0)
        {
            currentTagIndex = arg0;
            ClearView();
            GenerateLogs();
            lastTween.Kill();
            scrollRect.verticalNormalizedPosition = 0;
        }

        private void GenerateLogs()
        {
            var logs = WraDiagnostics.GetLogsWithTag(WraDiagnostics.GetTags()[currentTagIndex]);
            for (int i = 0; i < logs.Count; i++)
            {
                OnLog(logs[i]);   
            }
        }
    }
}
