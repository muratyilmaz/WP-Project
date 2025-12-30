namespace ServiceMS.Helpers;

public static class ServiceStatusHelper
{
    public static string ToText(short status)
    {
        return status switch
        {
            0 => "Acik",
            1 => "Islemde",
            2 => "Tamamlandi",
            3 => "Teslim Edildi",
            _ => "Bilinmiyor"
        };
    }
}