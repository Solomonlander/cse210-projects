namespace ScriptureMemorization
{
    public class Word
    {
        private string _wordText;
        private bool _isHidden;

        public Word(string word)
        {
            _wordText = word;
            _isHidden = false;
        }

        // hide the word 
        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden
        {
            get { return _isHidden; }
        }

        public string WordText
        {
            get { return _wordText; }
        }

        // return the word 
        public override string ToString()
        {
            return _isHidden ? new string('_', _wordText.Length) : _wordText;
        }
    }
}
