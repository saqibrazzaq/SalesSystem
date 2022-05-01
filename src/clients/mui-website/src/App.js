import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { Outlet } from "react-router-dom";
import PublicMenu from "./Components/PublicMenu/PublicMenu";

function App() {
  return (
    <Container>
      <PublicMenu />
      <Box sx={{mt: 1}}>
        <Outlet />
      </Box>
    </Container>
  );
}

export default App;
