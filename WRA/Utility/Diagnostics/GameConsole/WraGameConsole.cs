using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        public bool IsEditing => inputField.isFocused;
        
        [Inject] public List<ICommand> Commands;
        
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Transform logContainer;
        [SerializeField] private SimpleLog simpleLogPrefab;
        [SerializeField] private ScrollRect scrollRect;
    
        private List<string> executedCommands = new List<string>();

        private TweenerCore<float, float, FloatOptions> lastTween;
        private string currentTageName = "All";

        private string lastText = "";
        
        private int showintLastCommands = 0;

        private void Awake()
        {
            RegisterEvenets();
        }

        private void Update()
        {
            if (!IsEditing)
                return;
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                showintLastCommands++;
                RefreshInputField();
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                showintLastCommands--;
                RefreshInputField();
            }
            
            if (showintLastCommands == 0)
            {
                lastText = inputField.text;
            }
        }
        
        private void RefreshInputField()
        {
            showintLastCommands = Mathf.Clamp(showintLastCommands, 0, executedCommands.Count);
            if (showintLastCommands == 0)
            {
                inputField.text = lastText;
                return;
            }
            inputField.text = executedCommands[^showintLastCommands];
        }

        private void OnDestroy()
        {
            UnRegisterEvents();
        }
        
        public override void OnOpen()
        {
            base.OnOpen();
            transform.SetAsLastSibling();
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
            showintLastCommands = 0;
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
            inputField.OnSelect(null);
        }
    
        public void SetTag(string name)
        {
            var existTag = Logs.Diagnostics.GetTags().Find(ctg => string.Equals(ctg, name, StringComparison.CurrentCultureIgnoreCase));
            if (string.IsNullOrEmpty(existTag))
            {
                Logs.Diagnostics.Log($"Tag '{name}' not found", LogType.cmd);
                return;
            }
            if (string.IsNullOrEmpty(currentTageName))
            {
                currentTageName = "all";
            }
            currentTageName = name;
            ClearView();
            GenerateLogs();
            lastTween.Kill();
            scrollRect.verticalNormalizedPosition = 0;
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
            inputField.onSubmit.AddListener(ExecuteCommand);
            Logs.Diagnostics.OnLog.AddListener(OnLog);
        }
    
        private void UnRegisterEvents()
        {
            inputField.onSubmit.RemoveListener(ExecuteCommand);
            Logs.Diagnostics.OnLog.RemoveListener(OnLog);
        }

        private void OnLog(LogData arg0)
        {
            if (currentTageName.ToLower() != arg0.LogTag.ToLower())
                return;
        
            var log = Instantiate(simpleLogPrefab, logContainer);
            log.Bind(arg0.GetFinalMessage());
            lastTween = DOTween.To(() => scrollRect.verticalNormalizedPosition, x => scrollRect.verticalNormalizedPosition = x, 0,
                0.5f);
        }

        private void GenerateLogs()
        {
            var logs = Logs.Diagnostics.GetLogsWithTag(currentTageName);
            for (int i = 0; i < logs.Count; i++)
            {
                OnLog(logs[i]);   
            }
        }
    }
}
