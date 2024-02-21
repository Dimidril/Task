namespace Task.Models;

public class MailSettings
{
    /// <summary>
    /// SMPT хост
    /// </summary>
    public string Server { get; set; }
    
    /// <summary>
    /// Порт
    /// </summary>
    public int Port { get; set; }
    
    /// <summary>
    /// Логин для авторизации
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}