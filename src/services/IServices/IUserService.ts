import { ResponseDto } from "@/Models/Dto/ResponseDto";
import { Guid } from "guid-typescript";

export interface IUserService {
  FetchUser(): Promise<ResponseDto>;

  GetUser(id: string): Promise<ResponseDto>;

  GetUserQuery(query: string): Promise<ResponseDto>;
}
