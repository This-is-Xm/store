
using PetShot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.BLL
{
  public class CustomerService
  {
        //建立MyPetShop.DAL数据访问层中的MyPetShopEntities类实例db
        //我没找到这个MyPetShopEntities类在哪，能用就姑且用着吧,里面有很多内置的处理数据库数据的函数
        MyPetShopEntities db = new MyPetShopEntities();

        public List<PetShot.DAL.Customer> GetCustomer()
        {
            return db.Customer.ToList();
        }

        public List<Customer> GetCustomerByNameOREmail(string search) => db.Customer.Where(a => a.Name.Contains(search) || a.Email.Contains(search)).ToList();
        /// <summary>
        /// 检查输入的用户名和密码是否正确
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>若用户名和密码正确则返回用户Id，否则返回0</returns>
        public int CheckLogin(string name, string password)
    {
      //通过MyPetShop.DAL数据访问层中的Customer类查询输入的用户名和密码是否正确，若正确则返回相应的用户对象，否则返回null
      Customer customer = db.Customer.Where(c=> c.Name.Equals(name) && c.Password.Equals(password))
                                        .FirstOrDefault();
      if (customer != null)  //用户名和密码正确
      {
        return customer.CustomerId;
      }
      else  //用户名或密码错误
      {
        return 0;
      }
    }

    /// <summary>
    /// 修改用户Id对应用户的密码
    /// </summary>
    /// <param name="customerId">用户Id</param>
    /// <param name="password">新密码</param>
    public void ChangePassword(int customerId, string password)
    {
      Customer customer = db.Customer.Find(customerId);
      customer.Password = password;

      db.SaveChanges();
    }

    /// <summary>
    /// 将用户密码重置为相应的用户名
    /// </summary>
    /// <param name="name">输入的用户名</param>
    /// <param name="email">输入的Email</param>
    public void ResetPassword(string name, string email)
    {
      Customer customer = db.Customer.Where(c => c.Name.Equals(name) && c.Email.Equals(email)).First();
      customer.Password = name;
      db.SaveChanges();
    }

    /// <summary>
    /// 判断输入的用户名是否重名
    /// </summary>
    /// <param name="name">输入的用户名</param>
    /// <returns>当用户名重名时返回true，否则返回false</returns>
    public bool IsNameExist(string name)
    {
      //通过MyPetShop.DAL数据访问层中的Customer类查询输入的用户名是否重名，若重名则返回用户名，否则返回null
      var customers = db.Customer.Where(c => c.Name.Equals(name) );
      if (customers.Count()>0)//重名了
      {
        return true;
      }
      else//没找到，没重名
      {
        return false;
      }
    }

    public bool IsNameExistByUpdate(string nameOld,string nameNew)
    {
        //通过MyPetShop.DAL数据访问层中的Customer类查询输入的用户名是否重名，若重名则返回用户名，否则返回null
        var customers = db.Customer.Where(c => c.Name!=nameOld);//这里我修改过了，原来还有.Where(c => c.Name==nameNew);
            if (customers.Count() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 判断输入的用户名是否重名
    /// </summary>
    /// <param name="name">输入的用户名</param>
    /// <returns>当用户名重名时返回true，否则返回false</returns>
    public bool IsEmailExist(string name, string email)
{
    Customer customer = db.Customer.Where(c => c.Name.Equals(name) && c.Email.Equals(email)).First();
    if (customer != null)
    {
    return true;
    }
    else
    {
    return false;
    }
}

    /// <summary>
    /// 向MyPetShop数据库插入新用户记录
    /// </summary>
    /// <param name="name">用户名</param>
    /// <param name="password">密码</param>
    /// <param name="email">电子邮件地址</param>
    public void Insert(string name, string password, string email)
    {
      Customer customer = new Customer();
      customer.Name = name;
      customer.Password = password;
      customer.Email = email;

      db.Customer.Add(customer);
      db.SaveChanges();
    }

    internal void Update(Customer customer)
    {
        Customer customer1 = db.Customer.Find(customer.CustomerId);
        customer1.Name=customer.Name;
        customer1.Password=customer.Password;
        customer1.Email=customer.Email;
        db.SaveChanges();
    }

    internal void Delete(int customerId)
    {
        Customer customer1 = db.Customer.Find(customerId);
        db.Customer.Remove(customer1);
        db.SaveChanges();
    }
}
}
