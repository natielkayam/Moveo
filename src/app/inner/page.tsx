import { Card, CardContent, Typography, Avatar } from "@mui/material";
import { UserDto } from "@/Models/Dto/UserDto";

interface PageProps {
  userData: UserDto;
}

export default function Page({ userData }: PageProps) {
  return (
    <>
      <Card
        sx={{
          maxWidth: 345,
          margin: 2,
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}>
        <CardContent>
          <Avatar
            alt={`${userData.firstName} ${userData.lastName}`}
            src={userData.profilePicture}
            sx={{ width: 56, height: 56, marginBottom: 2 }}
          />
          <Typography variant="h5" component="div">
            {userData.firstName} {userData.lastName}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Email: {userData.email}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Date of Birth: {new Date(userData.dateOfBirth).toLocaleDateString()}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Phone: {userData.phone}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Address: {userData.address}
          </Typography>
        </CardContent>
      </Card>
    </>
  );
}
