using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Models;

namespace KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Services
{
    public class StaffService
    {
        private readonly List<StaffMember> _staffMembers = new();


        public void AddStaff(StaffMember staffMember)
        {
            _staffMembers.Add(staffMember);
        }

        public List<StaffMember> GetAllStaff()
        {
            return _staffMembers;
        }

        public StaffMember? GetStaffById(int id)
        {
            return _staffMembers.FirstOrDefault(s => s.StaffId == id);
        }

        public bool UpdateStaff(StaffMember updatedStaff)
        {
            var existingStaff = _staffMembers.FirstOrDefault(s => s.StaffId == updatedStaff.StaffId);

            if (existingStaff == null)
            {
                return false;
            }

            existingStaff.FullName = updatedStaff.FullName;
            existingStaff.Email = updatedStaff.Email;
            existingStaff.Position = updatedStaff.Position;
            existingStaff.Unit = updatedStaff.Unit;

            return true;
        }

        public bool DeleteStaff(int id)
        {
            var staffMember = _staffMembers.FirstOrDefault(s => s.StaffId == id);

            if (staffMember == null)
            {
                return false;
            }

            _staffMembers.Remove(staffMember);

            return true;
        }
    }

}
