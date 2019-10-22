using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Domain.BillManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.EntryManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.SourceManagement.Contract;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.DomainDialogs
{
    public class BillEditDialogControlViewModel : BindableBase, IDialogAware
    {
        //members
        private readonly IEntryManager _entryManager;
        private readonly IBillManager _billManager;
        private readonly ISourceManager _sourceManager;

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

//todo: for total sum it is necessary to listen to changes in the Object, extend it, wrap it or create UI-Model as to allow for that
        public float TotalSum
        {
            get => _totalSum;
            set => SetProperty(ref _totalSum, value);
        }

        //properties - commands
        public DelegateCommand<Entry> RemoveEntryCommand { get; }
        public DelegateCommand<Entry> EditEntryCommand { get; }
        public DelegateCommand AddEntryCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand SaveCurrentAndCreateNextBillToFillCommand { get; }
        public DelegateCommand SaveAndCloseCommand { get; }

        //properties - IDialogAware
        public string Title { get; set; }


        //ctors
        public BillEditDialogControlViewModel(IEntryManager entryManager, IBillManager billManager, ISourceManager sourceManager)
        {
            _entryManager = entryManager;
            _billManager = billManager;
            _sourceManager = sourceManager;

            RemoveEntryCommand = new DelegateCommand<Entry>(removeEntryCommand, (entry)=> entry!=null);
            EditEntryCommand = new DelegateCommand<Entry>(editEntryCommand, (entry) => entry != null);
            AddEntryCommand = new DelegateCommand(addEntryCommand);
            SaveCommand = new DelegateCommand(saveCurrentBill, canSaveBill);
            SaveCurrentAndCreateNextBillToFillCommand = new DelegateCommand(saveCurrentAndCreateNextBillToFillCommand, canSaveBill);
            SaveAndCloseCommand = new DelegateCommand(saveCurrentBillAndCloseDialog, canSaveBill);
        }



        //public methods
        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }



        //private methods
        private void addEntryCommand()
        {
            throw new NotImplementedException();
        }

        private void saveCurrentBill()
        {
            throw new NotImplementedException();
        }

        private void saveCurrentAndCreateNextBillToFillCommand()
        {
            throw new NotImplementedException();
        }

        private void saveCurrentBillAndCloseDialog()
        {
            throw new NotImplementedException();
        }

        private bool canSaveBill()
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
    }
}
