namespace MDL_Test_task.Models;

public class Mail
{
    /// <summary>
    /// Тема письма
    /// </summary>
    public string Subject { get; set; }
    
    /// <summary>
    /// Содержимое письма
    /// </summary>
    public string Body { get; set; }
    
    /// <summary>
    /// Получатели письма
    /// </summary>
    public List<string> Recipients { get; set; }
}