import App from "./App";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { createRoot } from "react-dom/client";
import Home from "./Pages/Home/Home";
import Products from "./Pages/Products/Products";
import Pricing from "./Pages/Pricing/Pricing";
import Blog from "./Pages/Blog/Blog";
import PhoneDetail from "./Components/PhoneDetail/PhoneDetail";
import Admin from "./Pages/Admin/Admin";
import General from "./Pages/Admin/PhoneProperties/General/General";
import Network from "./Pages/Admin/PhoneProperties/Network/Network";
import BrandHome from "./Pages/Admin/PhoneProperties/General/Brand/BrandHome";
import AvailabilityHome from "./Pages/Admin/PhoneProperties/General/Availability/AvailabilityHome";
import G2 from "./Pages/Admin/PhoneProperties/Network/2G/2G";
import G3 from "./Pages/Admin/PhoneProperties/Network/3G/3G";
import G4 from "./Pages/Admin/PhoneProperties/Network/4G/4G";
import G5 from "./Pages/Admin/PhoneProperties/Network/5G/5G";
import BrandEdit from "./Pages/Admin/PhoneProperties/General/Brand/BrandEdit";
import BrandDelete from "./Pages/Admin/PhoneProperties/General/Brand/BrandDelete";
const container = document.getElementById("app");
const root = createRoot(container); // createRoot(container!) if you use TypeScript
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route index element={<Home />} />
        <Route path="phone/:id" element={<PhoneDetail />} />
        <Route path="products" element={<Products />} />
        <Route path="pricing" element={<Pricing />} />
        <Route path="blog" element={<Blog />} />
        <Route path="admin" element={<Admin />}>
          <Route path="general" element={<General />}>
            <Route path="brand" element={<BrandHome />} />
            <Route path="brand-edit/:id" element={<BrandEdit />} />
            <Route path="brand-edit" element={<BrandEdit />} />
            <Route path="brand-delete/:id" element={<BrandDelete />} />
            <Route path="availability" element={<AvailabilityHome />} />
          </Route>
          <Route path="network" element={<Network />}>
            <Route path="2g" element={<G2 />} />
            <Route path="3g" element={<G3 />} />
            <Route path="4g" element={<G4 />} />
            <Route path="5g" element={<G5 />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
