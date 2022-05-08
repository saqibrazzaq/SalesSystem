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
import Body from "./Pages/Admin/PhoneProperties/Body/Body";
import BackMaterialHome from "./Pages/Admin/PhoneProperties/Body/BackMaterial/BackMaterialHome";
import FormFactorHome from "./Pages/Admin/PhoneProperties/Body/FormFactor/FormFactorHome";
import FrameMaterialHome from "./Pages/Admin/PhoneProperties/Body/FrameMaterial/FrameMaterialHome";
import IpCertificateHome from "./Pages/Admin/PhoneProperties/Body/IpCertificate/IpCertificateHome";
import BackMaterialEdit from "./Pages/Admin/PhoneProperties/Body/BackMaterial/BackMaterialEdit";
import FormFactorEdit from "./Pages/Admin/PhoneProperties/Body/FormFactor/FormFactorEdit";
import FrameMaterialEdit from "./Pages/Admin/PhoneProperties/Body/FrameMaterial/FrameMaterialEdit";
import IpCertificateEdit from "./Pages/Admin/PhoneProperties/Body/IpCertificate/IpCertificateEdit";
import BackMaterialDelete from "./Pages/Admin/PhoneProperties/Body/BackMaterial/BackMaterialDelete";
import FormFactorDelete from "./Pages/Admin/PhoneProperties/Body/FormFactor/FormFactorDelete";
import FrameMaterialDelete from "./Pages/Admin/PhoneProperties/Body/FrameMaterial/FrameMaterialDelete";
import IpCertificateDelete from "./Pages/Admin/PhoneProperties/Body/IpCertificate/IpCertificateDelete";
import Platform from "./Pages/Admin/PhoneProperties/Platform/Platform";
import OsHome from "./Pages/Admin/PhoneProperties/Platform/Os/OsHome";
import OsVersionHome from "./Pages/Admin/PhoneProperties/Platform/OsVersion/OsVersionHome";
import ChipsetHome from "./Pages/Admin/PhoneProperties/Platform/Chipset/ChipsetHome";
import ChipsetEdit from "./Pages/Admin/PhoneProperties/Platform/Chipset/ChipsetEdit";
import OsEdit from "./Pages/Admin/PhoneProperties/Platform/Os/OsEdit";
import ChipsetDelete from "./Pages/Admin/PhoneProperties/Platform/Chipset/ChipsetDelete";
import OsDelete from "./Pages/Admin/PhoneProperties/Platform/Os/OsDelete";
import OsVersionList from "./Pages/Admin/PhoneProperties/Platform/OsVersion/OsVersionList";
import OsVersionEdit from "./Pages/Admin/PhoneProperties/Platform/OsVersion/OsVersionEdit";
import OsVersionDelete from "./Pages/Admin/PhoneProperties/Platform/OsVersion/OsVersionDelete";
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

          <Route path="body" element={<Body />} >
            <Route path="back-material">
              <Route index element={<BackMaterialHome />} />
              <Route path="edit" element={<BackMaterialEdit />} />
              <Route path="edit/:id" element={<BackMaterialEdit />} />
              <Route path="delete/:id" element={<BackMaterialDelete />} />
            </Route>

            <Route path="form-factor">
              <Route index element={<FormFactorHome />} />
              <Route path="edit" element={<FormFactorEdit />} />
              <Route path="edit/:id" element={<FormFactorEdit />} />
              <Route path="delete/:id" element={<FormFactorDelete />} />
            </Route>

            <Route path="frame-material">
              <Route index element={<FrameMaterialHome />} />
              <Route path="edit" element={<FrameMaterialEdit />} />
              <Route path="edit/:id" element={<FrameMaterialEdit />} />
              <Route path="delete/:id" element={<FrameMaterialDelete />} />
            </Route>

            <Route path="ip-certificate">
              <Route index element={<IpCertificateHome />} />
              <Route path="edit" element={<IpCertificateEdit />} />
              <Route path="edit/:id" element={<IpCertificateEdit />} />
              <Route path="delete/:id" element={<IpCertificateDelete />} />
            </Route>
          </Route>

          <Route path="platform" element={<Platform />}>
            <Route path="os">
              <Route index element={<OsHome />} />
              <Route path="edit" element={<OsEdit />} />
              <Route path="edit/:id" element={<OsEdit />} />
              <Route path="delete/:id" element={<OsDelete />} />
            </Route>

            <Route path="os-version" element={<OsVersionHome />}>
              <Route path="list/:osId" element={<OsVersionList />} />
              <Route path="edit" element={<OsVersionEdit />} />
              <Route path="edit/:id" element={<OsVersionEdit />} />
              <Route path="delete/:id" element={<OsVersionDelete />} />
            </Route>

            <Route path="chipset">
              <Route index element={<ChipsetHome />} />
              <Route path="edit" element={<ChipsetEdit />} />
              <Route path="edit/:id" element={<ChipsetEdit />} />
              <Route path="delete/:id" element={<ChipsetDelete />} />
            </Route>
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
