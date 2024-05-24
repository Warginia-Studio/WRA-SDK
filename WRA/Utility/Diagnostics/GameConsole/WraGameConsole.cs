using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole.Commands;
using WRA.Utility.Diagnostics.Logs;
using Zenject;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class WraGameConsole : PanelBase
    {
        
        [Inject] public List<ICommand> Commands;
        
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
        
        public override void OnOpen()
        {
            base.OnOpen();
            var data =GetDataAsType<PanelDataBase>();
        }

        public override void OnClose()
        {
            // PanelManager.Instance.ClosePanel<WraGameConsole>(null);
        }

        public override void OnShow()
        {
            base.OnShow();
            transform.SetAsLastSibling();
        }
        
        public void ExecuteCommand(string command)
        {
            
            inputField.text = "";
            if (string.IsNullOrEmpty(command))
                return;
            executedCommands.Add(command);
            var splited = command.Split(" ");
            Logs.Diagnostics.Log(command, LogType.cmd, "CMD");
            if (splited.Length == 0)
            {
                Logs.Diagnostics.Log("Command is empty", LogType.cmd);
                return;
            }
            var cmd = Commands.Find(ctg => ctg.Name == splited[0]);
            if (cmd == null)
            {
                Logs.Diagnostics.Log($"Command '{splited[0]}' not found", LogType.cmd);
                return;
            }
            cmd.Execute(splited);
        }
    
        public void ClearLogs()
        {
            ClearView();
            Logs.Diagnostics.ClearLogs();
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
            inputField.onSubmit.AddListener(ExecuteCommand);
            Logs.Diagnostics.OnLog.AddListener(OnLog);
            Logs.Diagnostics.OnTagAdded.AddListener(OnTagAdded);
        }
    
        private void UnRegisterEvents()
        {
            tagSelector.onValueChanged.RemoveListener(OnTagChanged);
            inputField.onSubmit.RemoveListener(ExecuteCommand);
            Logs.Diagnostics.OnLog.RemoveListener(OnLog);
            Logs.Diagnostics.OnTagAdded.RemoveListener(OnTagAdded);
        }

        private void OnLog(LogData arg0)
        {
            if (currentTagIndex != 0 && arg0.LogTag != Logs.Diagnostics.GetTags()[currentTagIndex])
                return;
        
            var log = Instantiate(simpleLogPrefab, logContainer);
            log.Bind(arg0.GetFinalMessage());
            lastTween = DOTween.To(() => scrollRect.verticalNormalizedPosition, x => scrollRect.verticalNormalizedPosition = x, 0,
                0.5f);
        }
        
        private void OnTagAdded(string str)
        {
            tagSelector.ClearOptions();
            tagSelector.AddOptions(Logs.Diagnostics.GetTags());
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
            var logs = Logs.Diagnostics.GetLogsWithTag(Logs.Diagnostics.GetTags()[currentTagIndex]);
            for (int i = 0; i < logs.Count; i++)
            {
                OnLog(logs[i]);   
            }
        }
    }
}
