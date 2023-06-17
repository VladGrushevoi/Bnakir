import React from 'react'
import './App.css'
import { Header } from './components/Header/Header'
import { RouterProvider } from 'react-router-dom'
import { Router } from './router/Router'



function App(): React.JSX.Element {

    return (
        <>
            <div className='container h-screen bg-gray-100'>
                <Header />
                <RouterProvider router={Router} />
            </div>
        </>
    )
}

export default App
