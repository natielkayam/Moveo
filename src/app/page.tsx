"use client";

import * as React from "react";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import {
  Avatar,
  Button,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Typography,
} from "@mui/material";
import { UserService } from "@/services/userService";
import { UserDto } from "@/Models/Dto/UserDto";
import Inner from "./inner/page";

export default function Home() {
  const [users, setUsers] = React.useState<UserDto[]>([]);

  const [userclick, setUserclick] = React.useState(false);

  const [userData, setUserData] = React.useState<UserDto | null>();

  const userService = UserService.getInstance();

  React.useEffect(() => {}, [users]);

  const fetchUser = async () => {
    try {
      const response = await userService.FetchUser();

      setUsers((prevUsers) => [...prevUsers, response.result as UserDto]);
    } catch (error: any) {
      alert(error.message);
    }
  };

  const handleClick = (user: UserDto) => {
    setUserclick(true);
    setUserData(user);
  };

  return (
    <>
      <Box sx={{ flexGrow: 1, mt: 10, textAlign: "center" }}>
        <Box sx={{ p: 10 }}>
          <Typography variant="h4">Lobby Screen</Typography>
        </Box>
        <Button
          onClick={() => {
            fetchUser();
          }}
          sx={{ border: 1, borderRadius: 5 }}>
          Fetch More User
        </Button>

        <Box sx={{ justifyContent: "center", display: "flex", mt: 2 }}>
          <Grid>
            <List>
              {users.map((user) => (
                <ListItem key={user.id} onClick={() => handleClick(user)}>
                  <ListItemAvatar>
                    <Avatar src={user.profilePicture} />
                  </ListItemAvatar>
                  <ListItemText
                    primary={`${user.firstName} ${user.lastName}`}
                  />
                </ListItem>
              ))}
            </List>
          </Grid>
        </Box>
        <Box
          sx={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}>
          {" "}
          {userclick && userData && <Inner userData={userData} />}
        </Box>
      </Box>
    </>
  );
}
