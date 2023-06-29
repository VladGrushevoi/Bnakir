import React from 'react'
import './App.css'
import { Header } from './components/Header/Header'
import { RouterProvider } from 'react-router-dom'
import { ConfigureRouter } from './router/Router'



function App(): React.JSX.Element {
    const { router } = ConfigureRouter();
    return (
        <>
            <div className='container h-screen bg-gray-100'>
                <Header />
                <RouterProvider router={router} />
            </div>
        </>
    )
}

export default App
