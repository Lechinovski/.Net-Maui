using Contact.Modelo;

namespace Contact.service
{
    public interface RandomUserService
    {

        public Task<List<RandomUser>> Obter();
    }
}
