using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IContent
{
    void Delete(User user);
    void Delete(Department department);
    
    void Update(User user);
    void Update(Department department);

    void Add(User user);
    void Add(Department department);
    
}