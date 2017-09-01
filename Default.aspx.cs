using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;  // reflection namespace
using ERP.BOL;
using ERP.Manager;

namespace SimpleERP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PropertyInfo();
            bool a = insert();
        }
        public string test()
        {

            UsersBOL b = new UsersBOL();
            b.FirstName  ="t1";
            b.LastName ="t1";
            b.UserName="t1";
            b.CreatedOn = DateTime.Now;
            UsersManager m = new UsersManager();
            return m.test(b);

        }
        public bool insert()
        {

            UsersBOL b = new UsersBOL();
            b.FirstName = "t2";
            b.LastName = "t2";
            b.UserName = "t2";
            b.CreatedOn = DateTime.Now;
            UsersManager m = new UsersManager();
            return m.Insert(b);

        }
        public void PropertyInfo()
        {
            // get all public static properties of MyClass type
            MyClass c = new MyClass();
            c.ID = 1;
            c.Name = "aaa";
            BaseBOL bb = new EmployeeBOL();
            PropertyInfo[] propertyInfos;
            Type t = bb.GetType();
            propertyInfos = typeof(MyClass).GetProperties();
            // sort properties by name.
            Array.Sort(propertyInfos,
                    delegate(PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                    { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

            // write property names
            string prop = string.Empty;
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //prop = prop + propertyInfo.Name + " , " + c.GetType().GetProperty(propertyInfo.Name).GetValue(c, null) + ", ";
                
            }
            var customAttributes = (HelpAttribute[])typeof(MyClass).GetCustomAttributes(typeof(HelpAttribute), true);
            if (customAttributes.Length > 0)
            {
                var myAttribute = customAttributes[0];
                string value = myAttribute.HelpText;
                // TODO: Do something with the value
                prop = prop + value + "<\br>";
            }
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true).Length > 0)
                {
                    prop = prop + ((SimpleERP.HelpAttribute)(propertyInfo.GetCustomAttributes(typeof(HelpAttribute), true)[0])).HelpText;
                }
            }

            //car.GetType().GetProperty(propertyName).GetValue(car, null);
            

            Response.Write(prop);
        }
        public void PropertyInfo2()
        {
           
        }
        
    }
    class HelpAttribute : Attribute
    {
        public string HelpText { get; set; }

    }
    [Help(HelpText = "This is a class")]
    public class MyClass:Attribute
    {
        int id;
        [Help(HelpText = "PrimaryKey")]
        public int ID
        {
            get { return id;}
            set { id = value; }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}