import { RouterModule } from "@angular/router";
import CheckoutPage from "../pages/CheckoutPage";
import EmpresaFornecedores from "../pages/empresa_fornecedores";

const routes = [
    { path: "", component: EmpresaFornecedores},
  { path: "checkout", component: CheckoutPage },
  //{ path: "login", component: LoginPage },
  { path: "**", redirectTo: "/" }
];

const router = RouterModule.forRoot(routes,
  {
    useHash: true
  });

export default router;