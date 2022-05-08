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
import BrandEdit from "./Pages/Admin/PhoneProperties/General/Brand/BrandEdit";
import BrandDelete from "./Pages/Admin/PhoneProperties/General/Brand/BrandDelete";
import AvailabilityEdit from "./Pages/Admin/PhoneProperties/General/Availability/AvailabilityEdit";
import AvailabilityDelete from "./Pages/Admin/PhoneProperties/General/Availability/AvailabilityDelete";
import NetworkHome from "./Pages/Admin/PhoneProperties/Network/Network/NetworkHome";
import NetworkBandHome from "./Pages/Admin/PhoneProperties/Network/NetworkBand/NetworkBandHome";
import NetworkEdit from "./Pages/Admin/PhoneProperties/Network/Network/NetworkEdit";
import NetworkDelete from "./Pages/Admin/PhoneProperties/Network/Network/NetworkDelete";
import NetworkBandList from "./Pages/Admin/PhoneProperties/Network/NetworkBand/NetworkBandList";
import NetworkBandEdit from "./Pages/Admin/PhoneProperties/Network/NetworkBand/NetworkBandEdit";
import NetworkBandDelete from "./Pages/Admin/PhoneProperties/Network/NetworkBand/NetworkBandDelete";
import Sim from "./Pages/Admin/PhoneProperties/Sim/Sim";
import SimMultipleHome from "./Pages/Admin/PhoneProperties/Sim/Multiple/SimMultipleHome";
import SimSizeHome from "./Pages/Admin/PhoneProperties/Sim/Size/SimSizeHome";
import SimMultipleEdit from "./Pages/Admin/PhoneProperties/Sim/Multiple/SimMultipleEdit";
import SimMultipleDelete from "./Pages/Admin/PhoneProperties/Sim/Multiple/SimMultipleDelete";
import SimSizeEdit from "./Pages/Admin/PhoneProperties/Sim/Size/SimSizeEdit";
import SimSizeDelete from "./Pages/Admin/PhoneProperties/Sim/Size/SimSizeDelete";
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
            <Route path="brand">
              <Route index element={<BrandHome />} />
              <Route path="edit/:id" element={<BrandEdit />} />
              <Route path="edit" element={<BrandEdit />} />
              <Route path="delete/:id" element={<BrandDelete />} />
            </Route>

            <Route path="availability">
              <Route index element={<AvailabilityHome />} />
              <Route path="edit" element={<AvailabilityEdit />} />
              <Route path="edit/:id" element={<AvailabilityEdit />} />
              <Route path="delete/:id" element={<AvailabilityDelete />} />
            </Route>
          </Route>
          <Route path="network" element={<Network />}>
            <Route path="network">
              <Route index element={<NetworkHome />} />
              <Route path="edit" element={<NetworkEdit />} />
              <Route path="edit/:id" element={<NetworkEdit />} />
              <Route path="delete/:id" element={<NetworkDelete />} />
            </Route>

            <Route path="band" element={<NetworkBandHome />}>
              <Route path="list/:networkId" element={<NetworkBandList />} />
              <Route path="edit" element={<NetworkBandEdit />} />
              <Route path="edit/:id" element={<NetworkBandEdit />} />
              <Route path="delete/:id" element={<NetworkBandDelete />} />
            </Route>
          </Route>

          <Route path="sim" element={<Sim />}>
            <Route path="multiple">
              <Route index element={<SimMultipleHome />} />
              <Route path="edit" element={<SimMultipleEdit />} />
              <Route path="edit/:id" element={<SimMultipleEdit />} />
              <Route path="delete/:id" element={<SimMultipleDelete />} />
            </Route>
            <Route path="size">
              <Route index element={<SimSizeHome />} />
              <Route path="edit" element={<SimSizeEdit />} />
              <Route path="edit/:id" element={<SimSizeEdit />} />
              <Route path="delete/:id" element={<SimSizeDelete />} />
            </Route>
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
