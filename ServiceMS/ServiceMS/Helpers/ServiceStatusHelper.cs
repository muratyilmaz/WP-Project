namespace ServiceMS.Helpers;

public static class ServiceStatusHelper
{
    public static string ToText(short status)
    {
        return status switch
        {
            0 => "Açık",
            1 => "İşlemde",
            2 => "Tamamlandı",
            3 => "Teslim Edildi",
            _ => "Bilinmiyor"
        };
    }
    
    public static string StatusBadgeClass(short status)
    {
        return status switch
        {
            0 => "bg-danger",
            1 => "bg-warning text-dark",
            2 => "bg-success",
            3 => "bg-secondary",
            _ => "bg-dark"
        };
    }
}