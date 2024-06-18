export interface IUser {
    id: string;
    firstName: string;
    lastName: string;
    image: string;
    phoneNumber: string;
    email: string;
}

export interface ILogin {
    phoneNumber: string;
    password: string;
}

export interface IRegister {
    phoneNumber: string;
    password: string;
}

export interface ILoginResponse {
    message: string;
    statusCode: string;
    item: string
}