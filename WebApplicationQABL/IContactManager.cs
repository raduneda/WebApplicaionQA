using WebApplicationQATL;


namespace WebApplicationQABL
{
   public interface IContactManager
   {
      ContactDto Create(string value);
      bool Delete(int id);
      ContactDto Read(int id);
      ContactDto Update(ContactDto dto);
   }
}