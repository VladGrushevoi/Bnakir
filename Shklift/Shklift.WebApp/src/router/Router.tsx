import { createBrowserRouter } from "react-router-dom";
import { MainPage } from "../pages/MainPage/MainPage";
import { ReceiptPage } from "../pages/ReceiptPage/ReceiptPage";

export const Router = createBrowserRouter([
    {
        path: "/",
        element: <MainPage />,
        errorElement: <div>Error</div>
    },
    {
        path: "/main",
        element: <MainPage />,
        errorElement: <div>Error</div>
    },
    {
        path: "/receipt",
        element: <ReceiptPage />,
        errorElement: <div>Error</div>
    }
])