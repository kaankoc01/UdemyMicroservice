namespace UdemyMicroservice.Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("1cb07e8d-3bc7-4e6d-a483-20816cfc4e44");
        public string Username => "Ahmet16";
    }
}
