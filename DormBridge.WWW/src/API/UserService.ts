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

export const UserService = {
  async SignUp(data: UserSignUp): Promise<SignUpResponse> {
    const response = await api.post('/register', data);
    return response.data;
  },
};
