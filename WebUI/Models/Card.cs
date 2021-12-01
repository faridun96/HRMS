using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public enum StudyType
    {
        Дневное, Заочное
    }

    public enum PartyType
    {
        Беспартийный, Народно_демократическая_партия, Коммунистическая_партия, Аграрная_партия, Партия_экономических_реформ
    }

    public enum FamilyType
    {
        Холост, Женат, Разведен, Вдовец, Разведена, Вдова, Замужем
    }

    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Required(ErrorMessage ="Номер карты являеться обязательным")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Только цифры")]
        [Display(Name = "Номер карты")]
        public string Nomer { get; set; }

        [Required(ErrorMessage ="Фамилия являеться обязательным")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Только буквы и пробел")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Имя являеться обязательным")]
        [RegularExpression(@"^[^0-9\s]+$", ErrorMessage = "Только буквы")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Отчество являеться обязательным")]
        [RegularExpression(@"^[^0-9\s]+$", ErrorMessage = "Только буквы")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime BirthDay { get; set; }
        
        [Display(Name = "Место рождения")]
        public string BirthPlace { get; set; }
     
        [Display(Name = "Национальность")]
        public string Nationality { get; set; }
      
        [Display(Name = "Партийность")]
        public PartyType Party { get; set; }
       
        [Display(Name = "Профсоюз (Да/Нет)")]
        public bool IsInUnion { get; set; }


        #region Education
        [Display(Name = "Уровень образования")]
        public string Education { get; set; }

        [Display(Name = "Название образовательного учреждения")]
        public string AfterSchool { get; set; }
        [Display(Name = "Название школы")]
        public string School { get; set; }

        [Display(Name = "Вид обучения (дневное или заочное)")]
        public StudyType EducationType { get; set; }

        [Display(Name = "Специальность")]
        public string Degree { get; set; }

        [Display(Name = "Квалификация")]
        public string Profession { get; set; }

        [Display(Name = "Информация о дипломе")]
        public string Diploma { get; set; }
        #endregion

        #region Информация о профессии
        [Display(Name = "Основная профессия")]
        public string GeneralProfession { get; set; }

        [Display(Name = "Общий стаж работы")]
        public string AllWorkDuration { get; set; }

        [Display(Name = "Непрерывный стаж работы")]
        public string ContiniousAllWorkDuration { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Последнее место работы, причина увольнения")]
        public string LastJob { get; set; }

        #endregion

        #region Семья
        [Display(Name = "семейное положение")]
        public FamilyType FamilyStatus { get; set; }
        #endregion
        #region Паспорт
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }

        [Display(Name = "Серия паспорта")]
        public string PassportSerie { get; set; }

        [Display(Name = "Кем выдан")]
        public string PassportIssuer { get; set; }

        [Required(ErrorMessage ="Дата выдачи паспорта являеться обязательным")]
        [Display(Name = "Дата выдачи паспорта")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime PassportDate { get; set; }

        [Display(Name = "Домашний адрес")]
        public string Address { get; set; }
        #endregion

        #region Other
        [Display(Name = "Телефон")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Только цифры")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Дата заполнения являеться обязательным")]
        [Display(Name = "Дата заполнения")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]

        public DateTime Posted{ get; set; }
        #endregion

        #region Воинский учет

        [Display(Name = "Военнообязанный (Да/Нет)")]
        [DefaultValue(false)]
        public bool IsMilitary { get; set; }
        [Display(Name = "Группа учета")]
        public string MilitaryGroup { get; set; }
        [Display(Name = "Категория учета")]
        public string MilitaryCategory { get; set; }
        [Display(Name = "Состав")]
        public string MilitaryInstitution { get; set; }
        [Display(Name = "Воинское звание")]
        public string MilitaryPosition { get; set; }
        [Display(Name = "Военно-учетная специальность")]
        public string MilitaryProfession { get; set; }

        
        [Display(Name = "Годность к военной службе")]
        [DataType(DataType.MultilineText)]
        public string MilitaryHealth { get; set; }
        [Display(Name = "Название райвоенкомата по месту жительства")]
        public string MilitaryUnit { get; set; }
        [Display(Name = "Состоит на специальном учет №")]
        public string MilitarySpecialNumber { get; set; }
        #endregion

        #region Дополнительные сведения 

        [Display(Name = "Дополнительные сведения ")]
        public string AdditionalInfo { get; set; }

        [Display(Name = "Дата и причина увольнения")]
        [DataType(DataType.MultilineText)]
        public string ResignationReason { get; set; }
        #endregion
        public ICollection<Vacation> Vacations { get; set; }

        #region Аутентификация
        [Required]
        [Display(Name = "Администратор")]
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage ="Имя пользователя являеться обязательным")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Пароль являеться обязательным")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        #endregion

    }
}
