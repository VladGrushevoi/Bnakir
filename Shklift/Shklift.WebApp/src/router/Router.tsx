import { createBrowserRouter } from "react-router-dom";
import { MainPage } from "../pages/MainPage/MainPage";
import { ReceiptPage } from "../pages/ReceiptPage/ReceiptPage";
import { Transaction } from "../pages/ReceiptPage/useTransactionData";


export function ConfigureRouter () {

    const { transactionData, HandleTransaction } = Transaction();

    const Router = createBrowserRouter([
        {
            path: "/",
            element: <MainPage HandleTransaction={HandleTransaction} />,
            errorElement: <div>Error</div>
        },
        {
            path: "/main",
            element: <MainPage  HandleTransaction={HandleTransaction}/>,
            errorElement: <div>Error</div>
        },
        {
            path: "/receipt",
            element: <ReceiptPage transactionData={transactionData} />,
            errorElement: <div>Error</div>
        }
    ])

    return {
        router: Router,
    }
}

// export const Router = createBrowserRouter([
//     {
//         path: "/",
//         element: <MainPage HandleTransaction={HandleTransaction} />,
//         errorElement: <div>Error</div>
//     },
//     {
//         path: "/main",
//         element: <MainPage  HandleTransaction={HandleTransaction}/>,
//         errorElement: <div>Error</div>
//     },
//     {
//         path: "/receipt",
//         element: <ReceiptPage transactionData={transactionData} />,
//         errorElement: <div>Error</div>
//     }
// ])