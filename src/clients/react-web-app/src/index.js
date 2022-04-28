import App from "./App";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomeIndex from "./Home/HomeIndex";
import AdminHomeIndex from "./Admin/Home/AdminHomeIndex";
import AvailabilitiesHome from "./Admin/PhoneProperties/Availabilities/AvailabilitiesHome";
import BackMaterialIndex from "./Admin/PhoneProperties/BackMaterial/BackMaterialIndex";
import AvailabilityEdit from "./Admin/PhoneProperties/Availabilities/AvailabilityEdit";

const container = document.getElementById("root");
const root = createRoot(container); // createRoot(container!) if you use TypeScript
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="home" element={<HomeIndex />} />
        <Route path="admin">
          <Route path="home" element={<AdminHomeIndex />}>
            <Route path="availabilities" element={<AvailabilitiesHome />} />
            <Route path="availability-edit" element={<AvailabilityEdit />} />
            <Route path="back-material" element={<BackMaterialIndex />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
