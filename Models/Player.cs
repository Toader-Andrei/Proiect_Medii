using System.ComponentModel.DataAnnotations;

public class Player
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Numele este obligatoriu.")]
    [StringLength(100, ErrorMessage = "Numele nu poate avea mai mult de 100 de caractere.")]
    public string Name { get; set; } = string.Empty;

    [Range(5, 40, ErrorMessage = "Vârsta trebuie să fie între 5 și 40.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Poziția este obligatorie.Foloseste prescurtarile din engleza")]
    [StringLength(3)]
    public string Position { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Numărul de goluri trebuie să fie pozitiv sau egal cu 0.")]
    public int Goals { get; set; }
}
