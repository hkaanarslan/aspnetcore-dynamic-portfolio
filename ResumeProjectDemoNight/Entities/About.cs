using System.ComponentModel.DataAnnotations;

namespace ResumeProjectDemoNight.Entities
{
    public class About
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hakkımda yazısı boş bırakılamaz")]
        public string AboutText { get; set; }

        [Required(ErrorMessage = "Ana görsel URL boş bırakılamaz")]
        public string ImageUrl { get; set; }        // Ana sayfa avatar

        [Required(ErrorMessage = "Profil fotoğrafı URL boş bırakılamaz")]
        public string AboutImageUrl { get; set; }   // Hakkımda vesikalık

        [Required(ErrorMessage = "CV linki boş bırakılamaz")]
        public string CvUrl { get; set; }
    }
}
