

using BindingToObject.Models;
using System.Collections.ObjectModel;

namespace CollectionExample;

public partial class MainPage : ContentPage
{

    #region   מכיון שרשימה לא יכולה להודיע למסך על הוספה/מחיקה של ערך מהרשימה נשתמש באוסף שכן יודע

    //public List<Student> Students {get;set;}
            #endregion
    public ObservableCollection<Student> Students { get; set; }

    #region כדי שהמסך יתעדכן כתוצאה מעדכון הסטודנט עלינו להפעיל את אירוע בכל שינוי ערך שלו. לכן עלינו ליצור אובייקט מגבה
    private Student _student;
    #endregion

    #region בכל שינוי בסטודנט נפעיל את האירוע
    public Student Student { get=>_student; set { if (value != _student) { _student = value;OnPropertyChanged("Student"); } } }
    #endregion

    public MainPage()
    {

        Student = new() { Name = "Roni", Image = "roni.jpg", BirthDate = new DateTime(2006, 2, 19) };
        Students = new ObservableCollection<Student>();
        Students.Add(Student);
        Students.Add(new Student { Name = "Omer", BirthDate = new DateTime(2006, 2, 9), Image = "omer.jpg" });

        InitializeComponent();
        this.BindingContext = this;



    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //מאחורי הקלעים ה
        //ObservableCollection מפעיל אירוע
        Students.Add(new Student() { Name = "יהלי", BirthDate = new DateTime(2006, 1, 12), Image = "yali.jpg" });
       
    }

    //private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Picker picker = sender as Picker;
    //    Student=picker.SelectedItem as Student;
    //   OnPropertyChanged("Student");
    //}
}





