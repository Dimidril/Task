namespace Task.Models;

public class DbMail
{
    /// <summary>
    /// ID записи
    /// </summary>
    public int Id { get; set; }
    
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
    public string Recipients { get; set; }
    
    /// <summary>
    /// Время и дата отправки
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>
    /// Результат операции
    /// </summary>
    public string Result { get; set; } = "Ok";

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string FailedMessage { get; set; } = string.Empty;
}