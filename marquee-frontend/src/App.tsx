import { useState } from 'react'
import { Button } from './components/ui/button'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <Button>Click me please please please!</Button>
      </div>
    </>
  )
}

export default App
