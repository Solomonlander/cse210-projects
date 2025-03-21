public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToShortDateString();  // Automatically assigns today's date
    }

    public string FormatForSaving()
    {
        return $"{Prompt} | {Response} | {Date}";
    }

    public override string ToString()
    {
        return $"{Prompt}\n{Response}\n{Date}";
    }
}