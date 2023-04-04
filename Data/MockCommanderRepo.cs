
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public Command GetCommandById(int id)
        {
            return new Command { Id = id, HowTo = "restart pc", Line = "sudo reboot", Platform = "ubuntu" };
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>(){
                new Command{Id = 0, HowTo="restart pc", Line="sudo reboot", Platform="ubuntu"},
                new Command{Id = 1, HowTo="restart pc", Line="sudo reboot", Platform="ubuntu"},
                new Command{Id = 2, HowTo="restart pc", Line="sudo reboot", Platform="ubuntu"},
                new Command{Id = 3, HowTo="restart pc", Line="sudo reboot", Platform="ubuntu"}
            };

            return commands;
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}