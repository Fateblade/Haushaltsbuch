using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Domain.BillManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.EntryManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.SourceManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Castle.Components.DictionaryAdapter;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.DomainDialogs
{
    public class BillEditDialogControlViewModel : BindableBase, IDialogAware
    {
        //members
        private readonly IEntryManager _entryManager;
        private readonly IBillManager _billManager;
        private readonly ISourceManager _sourceManager;
        private Bill _originalBillToEdit;

        //members - backing fields
        private ObservableCollection<Source> _availableLocationsToChooseFrom;
        private Source _selectedLocation;
        private DateTime? _selectedDate;
        private ObservableCollection<Entry> _entriesOfBillToDisplay;
        private float _totalSum;



        //events
        public event Action<IDialogResult> RequestClose;



        //properties
        public ObservableCollection<Source> AvailableLocationsToChooseFrom
        {
            get => _availableLocationsToChooseFrom;
            set => SetProperty(ref _availableLocationsToChooseFrom, value);
        }

        public Source SelectedLocation
        {
            get => _selectedLocation;
            set => SetProperty(ref _selectedLocation, value, replaceLocationOfAllEntriesWithSelectedLocation);
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value, replaceDateOfAllEntriesWithSelectedDate);
        }

        public ObservableCollection<Entry> EntriesOfBillToDisplay
        {
            get => _entriesOfBillToDisplay;
            set => SetProperty(ref _entriesOfBillToDisplay, value);
        }

        //todo: for total sum it is necessary to listen to changes in the object, extend it, wrap it or create UI-Model as to allow for that
        public float TotalSum
        {
            get => _totalSum;
            set => SetProperty(ref _totalSum, value);
        }

        //properties - commands
        public DelegateCommand<Entry> RemoveEntryCommand { get; }
        public DelegateCommand<Entry> EditEntryCommand { get; }
        public DelegateCommand AddEntryCommand { get; }
        public DelegateCommand AcceptInputAndCloseDialogCommand { get; }
        public DelegateCommand AbortAndCloseDialogCommand { get; }

        //properties - IDialogAware
        public string Title { get; set; }


        //constructors
        public BillEditDialogControlViewModel(IEntryManager entryManager, IBillManager billManager, ISourceManager sourceManager)
        {
            _entryManager = entryManager;
            _billManager = billManager;
            _sourceManager = sourceManager;

            RemoveEntryCommand = new DelegateCommand<Entry>(removeEntryCommand, (entry) => entry != null);
            EditEntryCommand = new DelegateCommand<Entry>(editEntryCommand, (entry) => entry != null);
            AddEntryCommand = new DelegateCommand(addEntryCommand);
            AcceptInputAndCloseDialogCommand = new DelegateCommand(readyInputAndCloseDialog, isInputAcceptable)
                .ObservesProperty(()=>SelectedDate)
                .ObservesProperty(()=>SelectedLocation);
            AbortAndCloseDialogCommand = new DelegateCommand(closeAndDiscardChanges);

            EntriesOfBillToDisplay = new ObservableCollection<Entry>();
        }



        //public methods
        public bool CanCloseDialog()
        {
            return hasUserMadeUnsavedChanges();
        }

        public void OnDialogClosed()
        {
            //min as default if set to null for datetime
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (!parameters.ContainsKey("Title"))
            {
                throw new ArgumentException(
                    "Parameter 'Title' is missing in given parameters. Cannot create useful confirmation dialog without it");
            }

            if (!parameters.ContainsKey("Request"))
            {
                throw new ArgumentException(
                    "Parameter 'Request' is missing in given parameters. Cannot create useful confirmation dialog without it");
            }

            Title = parameters.GetValue<string>("Title");
            var request = parameters.GetValue<BillEditDialogRequest>("Request");

            _originalBillToEdit = request.BillToEdit;
            if (request.BillToEdit != default)
            {
                SelectedDate = _originalBillToEdit.BuyDate;
                SelectedLocation = AvailableLocationsToChooseFrom.FirstOrDefault(t => t.Id == _originalBillToEdit.BoughtAtSourceId);
                loadEntriesForOriginalBill();
            }
        }



        //private methods
        private void addEntryCommand()
        {
            EntriesOfBillToDisplay.Add(new Entry()
            { 
                Date = SelectedDate ?? DateTime.MinValue,
                SourceID = SelectedLocation?.Id ?? -1
            });
        }

        private void readyInputAndCloseDialog()
        {
            //ready bill to be saved 
            //tell caller that everything is done and he can proceed according to input
        }

        private bool isInputAcceptable()
        {
            return SelectedDate.HasValue
                   && SelectedLocation != null;
        }

        private void closeAndDiscardChanges()
        {
            throw new NotImplementedException();
        }


        private void editEntryCommand(Entry obj)
        {
            throw new NotImplementedException();
        }

        private void removeEntryCommand(Entry entryToRemove)
        {
            throw new NotImplementedException();
        }

        private void replaceLocationOfAllEntriesWithSelectedLocation()
        {
            throw new NotImplementedException();
        }

        private void replaceDateOfAllEntriesWithSelectedDate()
        {
            throw new NotImplementedException();
        }

        private bool hasUserMadeUnsavedChanges()
        {
            var selectedDateEqualsOriginalBillBuyDate =
                (SelectedDate != null && SelectedDate.Value.Equals(_originalBillToEdit?.BuyDate))
                || (SelectedDate == null && _originalBillToEdit == null);

            var selectedLocationEqualsOriginalBillBoughtAtSourceId =
                (SelectedLocation != null && SelectedLocation.Id.Equals(_originalBillToEdit?.BoughtAtSourceId))
                || (SelectedLocation == null && _originalBillToEdit == null);

            var unsavedEntriesHaveBeenAdded =
                (_originalBillToEdit == null && EntriesOfBillToDisplay.Count > 0)
                || (_originalBillToEdit != null && (EntriesOfBillToDisplay.Count != _originalBillToEdit.BoughtEntryIds.Count
                                                    || EntriesOfBillToDisplay.Any(t => !_originalBillToEdit.BoughtEntryIds.Contains(t.Id))));

            return selectedDateEqualsOriginalBillBuyDate
                   && selectedLocationEqualsOriginalBillBoughtAtSourceId
                   && !unsavedEntriesHaveBeenAdded;
        }

        private void loadEntriesForOriginalBill()
        {
            EntriesOfBillToDisplay = new ObservableCollection<Entry>(
                _entryManager
                    .GetEntries()
                    .Where(t => _originalBillToEdit.BoughtEntryIds.Contains(t.Id))
                );
        }

        private void saveBill()
        {
            var newBillNeedsToBeCreated = _originalBillToEdit == null || _originalBillToEdit.Id < 1;
            if (newBillNeedsToBeCreated)
            {
                Bill newBillToSave = new Bill
                {
                    BuyDate = SelectedDate.Value,
                    BoughtAtSourceId = SelectedLocation.Id,
                    BoughtEntryIds = new List<int>()
                };
                foreach (var entry in EntriesOfBillToDisplay)
                {
                    newBillToSave.BoughtEntryIds.Add(entry.Id);
                }

                _billManager.Add(newBillToSave);

                _originalBillToEdit = newBillToSave;
            }
            else
            {
                _originalBillToEdit.BuyDate = SelectedDate.Value;
                _originalBillToEdit.BoughtAtSourceId = SelectedLocation.Id;
                _originalBillToEdit.BoughtEntryIds.Clear();
                foreach (var entry in EntriesOfBillToDisplay)
                {
                    _originalBillToEdit.BoughtEntryIds.Add(entry.Id);
                }

                _billManager.Update(_originalBillToEdit);
            }
        }
    }
}
