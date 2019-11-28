using System;

namespace LeftToDo
{

    class StartMenu
    {

        private ConsoleKeyInfo startMenuChoice;

        TaskList taskList = new TaskList();
        ArchiveList archiveList = new ArchiveList(); 

        public void PresentStartMenu()
        {
            start:
            Console.WriteLine();
            Console.WriteLine("[1] Lägg till uppgift");
            Console.WriteLine("[2] Visa lista på uppgifter");
            Console.WriteLine("[3] Arkivera uppgifter");
            Console.WriteLine("[4] Visa arkiv");
            Console.WriteLine("[5] Avsluta");
            Console.WriteLine("Välj:");

            startMenuChoice = Console.ReadKey();

            switch(startMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    taskList.CreateTask();
                    goto start;
                case ConsoleKey.D2:
                    int count = 0;
                    foreach(Task task in taskList.listOfTasks)
                    {
                        count += 1;
                        if (task.done == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Uppgift [{count}]: {task.activityName} Utförd {0}", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine($"Uppgift [{count}]: {task.activityName} Deadline: {task.activityDueDate}");
                        }
                    }
                    taskList.ChangeStateOfTask();
                    goto start;
                case ConsoleKey.D3:
                    int index = 0;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        index += 1;
                        if (task.done == true)
                        {
                            Console.WriteLine(task.activityName);
                            archiveList.listOfArchive.Add(new Task(task.activityName, task.activityDueDate, task.done));
                        }
                        else if(task.done == false)
                        {
                            continue;
                        }
                    }

                    startLoop:
                    int atIndex = -1;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        atIndex += 1;
                        if (task.done == true)
                        {
                                Console.WriteLine(atIndex);
                                taskList.listOfTasks.RemoveAt(atIndex);
                                goto startLoop;
                        }
                        else if (task.done == false)
                        {
                           continue;     
                        }
                    }                    
                    goto start;
                case ConsoleKey.D4:
                    foreach (Task archivedTask in archiveList.listOfArchive)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Uppgift: {archivedTask.activityName} Utförd {0}", Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    goto start;
                case ConsoleKey.D5:
                    return;
                default:
                    goto start;
            }
        }
    }
}