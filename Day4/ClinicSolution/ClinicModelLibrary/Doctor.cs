namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public double Phone { get; set; }
        public double Fee { get; set; }

        public Doctor(int id, string name, string qualification, string specialization, int experience, double phone, double fee)
        {
            Id = id;
            Name = name;
            Qualification = qualification;
            Specialization = specialization;
            Experience = experience;
            Phone = phone;
            Fee = fee;
        }

        public Doctor()
        {

        }

        public override string ToString()
        {
            return $"Id:{Id}\nName: {Name}\nQualification: {Qualification}\nSpecialization: {Specialization}\n" +
                $"Experience: {Experience}\nFee: {Fee}\nPhone: {Phone}";
        }

    }
}
