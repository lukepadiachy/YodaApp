using Azure;
using Azure.AI.OpenAI;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YodaApp.Model;
using YodaApp.Services;
using YodaApp.Views;

namespace YodaApp.ViewModels
{
    public partial class FunFactsPageViewModel : BaseViewModel
    {
        private IYodaResponse _helper;

        private ChatMessage _response;

        public ChatMessage Response
        {
            get { return _response; }
            set
            {
                _response = value;

                OnPropertyChanged();
            }
        }

        public FunFactsPageViewModel(IYodaResponse helper)
        {
            _helper = helper;
        }

        [RelayCommand]
        public async void GetResponses()
        {
            Response = await _helper.GetCompletion();
        }
    }
}

