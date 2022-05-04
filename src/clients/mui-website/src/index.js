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
            <Route path="availability-edit" element={<AvailabilityEdit />} />
            <Route path="availability-edit/:id" element={<AvailabilityEdit />} />
            <Route path="availability-delete/:id" element={<AvailabilityDelete />} />
          </Route>
          <Route path="network" element={<Network />}>
            <Route path="network" element={<NetworkHome />} />
            <Route path="network-edit" element={<NetworkEdit />} />
            <Route path="network-edit/:id" element={<NetworkEdit />} />
            <Route path="network-delete/:id" element={<NetworkDelete />} />
            <Route path="band" element={<NetworkBandHome />} >
              <Route path="list/:networkId" element={<NetworkBandList />} />
              <Route path="edit" element={<NetworkBandEdit />} />
              <Route path="edit/:id" element={<NetworkBandEdit />} />
              <Route path="delete/:id" element={<NetworkBandDelete />} />
            </Route>
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
