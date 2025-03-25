import { ResponseDto } from "@/Models/Dto/ResponseDto";
import { IUserService } from "./IServices/IUserService";
import axios from "axios";

const BASE_API_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export class UserService implements IUserService {
  private static instance: UserService;

  // Private constructor to prevent direct instantiation
  private constructor() {}

  // Static method to get the instance of AuthService
  public static getInstance(): UserService {
    if (!UserService.instance) {
      UserService.instance = new UserService();
    }
    return UserService.instance;
  }

  async FetchUser(): Promise<ResponseDto> {
    try {
      const response = await axios.post<ResponseDto>(
        `${BASE_API_URL}/api/users/Fetch`
      );

      const responseDto: ResponseDto = {
        result: response.data.result,
        isSuccess: response.data.isSuccess,
        message: response.data.message,
      };

      if (!responseDto.isSuccess) {
        throw new Error(responseDto.message);
      }

      return responseDto;
    } catch (error) {
      console.error(error);

      if (axios.isAxiosError(error)) {
        throw new Error(error.message);
      }

      if (error instanceof Error) {
        throw new Error(error.message);
      }

      throw new Error("An unexpected error occurred");
    }
  }

  async GetUser(id: string): Promise<ResponseDto> {
    try {
      const response = await axios.get<ResponseDto>(
        `${BASE_API_URL}/api/users/${id}`
      );

      const responseDto: ResponseDto = {
        result: response.data.result,
        isSuccess: response.data.isSuccess,
        message: response.data.message,
      };

      if (!responseDto.isSuccess) {
        throw new Error(responseDto.message);
      }

      return responseDto;
    } catch (error) {
      console.error(error);

      if (axios.isAxiosError(error)) {
        throw new Error(error.message);
      }

      if (error instanceof Error) {
        throw new Error(error.message);
      }

      throw new Error("An unexpected error occurred");
    }
  }

  async GetUserQuery(query: string): Promise<ResponseDto> {
    try {
      const response = await axios.get<ResponseDto>(
        `${BASE_API_URL}/api/users/search`,
        {
          params: { query: query },
        }
      );

      const responseDto: ResponseDto = {
        result: response.data.result,
        isSuccess: response.data.isSuccess,
        message: response.data.message,
      };

      if (!responseDto.isSuccess) {
        throw new Error(responseDto.message);
      }

      return responseDto;
    } catch (error) {
      console.error(error);

      if (axios.isAxiosError(error)) {
        throw new Error(error.message);
      }

      if (error instanceof Error) {
        throw new Error(error.message);
      }

      throw new Error("An unexpected error occurred");
    }
  }
}
