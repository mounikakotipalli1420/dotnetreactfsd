namespace DoctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public float Experience { get; set; }
        public Doctor()
        {
            Experience = 0.0f;
        }

        public Doctor(int id, string name, int phone, float experience)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Experience = experience;
        }
        public override string ToString()
        {
            return $"Doctor Id : {Id}\nDoctor Name : {Name}\nDoctor Experience :  {Experience}";
        }


    }
}