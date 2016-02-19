using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.VoiceCommands;

namespace RandomThought.VoiceCommandService
{
    public sealed class AppCommand : IBackgroundTask
    {
        private BackgroundTaskDeferral _taskDeferral;
        private VoiceCommandServiceConnection _voiceServiceConnection;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _taskDeferral = taskInstance.GetDeferral();

            taskInstance.Canceled += TaskInstance_Canceled;

            AppServiceTriggerDetails triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if (triggerDetails != null && triggerDetails.Name == "AppCommand")
            {
                try
                {
                    _voiceServiceConnection = VoiceCommandServiceConnection.FromAppServiceTriggerDetails(triggerDetails);
                    _voiceServiceConnection.VoiceCommandCompleted += VoiceServiceConnection_VoiceCommandCompleted;

                    VoiceCommand voiceCommand = await _voiceServiceConnection.GetVoiceCommandAsync();

                    if (voiceCommand.CommandName == "somethingInteresting")
                        SaySomethingInteresting();
                }
                finally
                {
                    if (_taskDeferral != null)
                        _taskDeferral.Complete();
                }
            }

            _taskDeferral.Complete();
        }

        private async void SaySomethingInteresting()
        {
            VoiceCommandResponse response = VoiceCommandResponse.CreateResponse(GetRandomThoughtMessage());

            await _voiceServiceConnection.ReportSuccessAsync(response);
        }

        private void VoiceServiceConnection_VoiceCommandCompleted(VoiceCommandServiceConnection sender, VoiceCommandCompletedEventArgs args)
        {
            if (_taskDeferral != null)
                _taskDeferral.Complete();
        }

        private void TaskInstance_Canceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
        }

        private VoiceCommandUserMessage GetRandomThoughtMessage()
        {
            return new VoiceCommandUserMessage()
                {
                    DisplayMessage = string.Format("I can\'t come up with anything on {0}s", DateTime.Now.DayOfWeek),
                    SpokenMessage = string.Format("It\'s {0}, I\'ve got nothing", DateTime.Now.DayOfWeek)
                };
        }
    }
}
