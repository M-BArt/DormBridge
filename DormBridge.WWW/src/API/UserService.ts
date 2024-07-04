import { api } from 'boot/axios';

export interface UserSignUp {
  username: string;
  email: string;
  password: string;
  repeatPassword: string;
  studentId: string;
}

export interface SignUpResponse {
  message: string;
}

export interface UserSignIn {
  login: string;
  password: string;
}

export interface SignInResponse {
  message: string;
}

export const UserService = {
  async SignUp(data: UserSignUp): Promise<SignUpResponse> {
    const response = await api.post('/register', data);
    return response.data;
  },

  async SignIn(data: UserSignIn): Promise<SignInResponse> {
    const response = await api.post('/login', data);
    return response.data;
  },
};
