import { UserDto } from "./UserDto";

export interface ResponseDto {
  result: UserDto | Array<UserDto> | null;
  isSuccess: boolean;
  message: string;
}
