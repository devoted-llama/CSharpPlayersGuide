using System;
public class ThePasswordValidator : IDo {

    public void Do() {


        while (true) {
            Console.Write("Enter a password to validate: ");
            string password = Console.ReadLine();
            bool valid = PasswordValidator.ValidatePassword(password);
            string validString = valid ? "valid" : "invalid";
            Console.WriteLine($"Password is {validString}");
        }

    }




}

public class PasswordValidator {
    public static bool ValidatePassword(string password) {

        bool containsUppercase = false;
        bool containsLowercase = false;
        bool containsNumber = false;
        foreach (var c in password) {
            if (char.IsUpper(c)) {
                containsUppercase = true;
            }
            if (char.IsLower(c)) {
                containsLowercase = true;
            }
            if (char.IsDigit(c)) {
                containsNumber = true;
            }
            if (c == 'T' || c == '&') {
                return false;
            }
        }
        if (password.Length < 6 || password.Length > 13 || containsUppercase == false || containsLowercase == false || containsNumber == false) {
            return false;
        }
        return true;
    }

}
