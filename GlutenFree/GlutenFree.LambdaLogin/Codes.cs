namespace GlutenFreeApp.Login
{
    enum Codes
    {

        //Success
        GenericSuccess = 200,

        //Login
        //LoginSuccessful = 200,
        LoginUserPasswordError = 400,
        LoginVerificationError = 401,
        LoginUserNotExists = 402,
        LoginTokenNotExists = 403,
        UpdatePasswordWrongToken = 406,
        UpdateUserPasswordError = 407,
        PasswordResetFirstStepError = 408,
        LoginGenericError = 409,

        //Registration
        //RegistrationSuccessful = 210,
        RegistrationError = 410,
        RegistrationUserExistsError = 411,
        RegistrationEmailExistsError = 412,
        RegistrationEmailNotValid = 413,

        //Task
        //TaskSuccess = 220,
        TaskUsernameError = 420,
        TaskGenericError = 421,
        TaskExistsError = 422,
        TaskDoesNotExistsError = 423,
        TaskAddError = 424,
        TaskRemoveError = 425,
        TaskWrongOperation = 426,
        TaskGetNotVerifiedError = 427,

        //GenericErrors
        RequestNotFound = 490,
        DatabaseConnectionError = 491,
        ToBeAdded = 498,
        GenericError = 499,

    }

    class CodesService
    {
        public static string ResponseCode(int code)
        {
            return code switch
            {
                //GenericSuccess
                200 => "Generic - Successful operation",

                //Login
                400 => "Login - Wrong username/password",
                401 => "Login - Missing verification",
                402 => "Login - User does not exists",
                403 => "Login - Token does not exists",
                406 => "Reset Password - Wrong Token",
                407 => "Reset Password - Error",
                408 => "Reset Password - Couldn't send token or DB error.",
                409 => "Login - Generic Error",

                //Registration
                210 => "Registration - Successful registration",
                410 => "Registration - Something went wrong with registration",
                411 => "Registration - User already exists",
                412 => "Registration - Email already in use",
                413 => "Registration - Email not valid",

                //GenericError
                490 => "RequestNotFound",
                491 => "Connection with Database not established",
                498 => "To Be Added",
                499 => "Something went wrong",
                //Default
                _ => "Request not found.",
            };
        }
    }
}
