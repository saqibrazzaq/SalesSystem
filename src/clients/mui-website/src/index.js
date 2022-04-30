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

          </Route>
          <Route path="network" element={<Network />}>
            
          </Route>
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);
