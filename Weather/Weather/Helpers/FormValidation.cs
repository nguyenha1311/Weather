using Xamarin.Forms;

namespace Weather.Helpers {
    public class FormValidation : Behavior<Entry> {
        public int MaxLength {
            get; set;
        }

        /// <summary>
        /// On Attached To event
        /// </summary>
        /// <param name="bindable">the entry.</param>
        protected override void OnAttachedTo(Entry bindable) {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }
        
        /// <summary>
        /// On Detaching From event
        /// </summary>
        /// <param name="bindable">the entry.</param>
        protected override void OnDetachingFrom(Entry bindable) {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }
        /// <summary>
        /// Validate when entry text is changed
        /// </summary>
        /// <param name="sender">the entry.</param>
        /// <param name="e">text changed event args.</param>
        void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
            var entry = (Entry)sender;

            // if Entry text is longer then valid length
            if(entry.Text.Length > MaxLength) {
                string entryText = entry.Text;
                entryText = entryText.Remove(entryText.Length - 1); // remove last char
                entry.Text = entryText;
            }
        }
    }
}
