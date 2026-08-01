using System;
using System.Diagnostics;
class cmds {
    public static void sleeps(int i) 
    { 
        System.Threading.Thread.Sleep(i);
    
    }
    public static void runs(String args)
    {
        int a = 0;
        String b;
        b = args.Trim();
        try
        {

            Process.Start(args);
            
        }
        catch(Exception e)
        { 
            a = 1;
            
        }
        if (a == 1) 
        {
            Console.WriteLine(args);
            try
            {
                // Configure the process start info
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",              // Run CMD
                    Arguments = "/c " + args,       // /c = run command and exit
                    RedirectStandardOutput = true,     // Capture output
                    RedirectStandardError = true,      // Capture errors
                    UseShellExecute = false,           // Required for redirection
                    CreateNoWindow = true              // Hide CMD window
                };
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();

                    // Read the output and errors
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Display results
                    Console.WriteLine("=== OUTPUT ===");
                    Console.WriteLine(output);

                    if (!string.IsNullOrWhiteSpace(errors))
                    {
                        Console.WriteLine("=== ERRORS ===");
                        Console.WriteLine(errors);
                    }

                }
            }
            catch (Exception e)
            {
                a = 0;
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
    public static String gets() 
    {
        String cline = ">";
        Console.Write(cline);
        cline = Console.ReadLine().Trim();

        return cline;
    }
    public static void runsLoop()
    {
        String a = "";
        while (true)
        {
            a = gets();
            if (a == "exit" || a == "EXIT" || a == "exit ") System.Environment.Exit(0);
            runs(a);
       
            
        
        
        }
    
    }

}









class cmdline
{
    public static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        
        Console.WriteLine("Hello, World!");
        cmds.runsLoop();
    }
}