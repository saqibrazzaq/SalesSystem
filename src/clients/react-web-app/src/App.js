import React, { Component } from 'react'
import { Outlet } from 'react-router-dom'
import PublicMenu from './Menu/PublicMenu'

export class App extends Component {
  render() {
    return (
      <div className='ui container'>
        <PublicMenu />
        <Outlet />
      </div>
    )
  }
}

export default App