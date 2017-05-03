using WebApplicationQATL;


namespace WebApplicationQABL
{
   public interface IAboutManager
   {
      AboutDto Create(string value);
      bool Delete(int id);
      AboutDto Read(int id);
      AboutDto Update(AboutDto dto);
   }
}