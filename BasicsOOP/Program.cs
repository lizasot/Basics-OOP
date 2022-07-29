using FileManager;

var userInterface = new ConsoleInterface();

var fileManagerLogic = new FileManagerLogic(userInterface);
fileManagerLogic.Run();