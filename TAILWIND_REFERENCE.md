# Tailwind CSS Utility Classes Reference

Quick reference for the Tailwind utilities used in Pharmatrack.Client components.

## Layout & Flexbox

### Container & Spacing
- `max-w-7xl mx-auto px-4`: Centered container with max width and horizontal padding
- `p-6`: Padding all sides (1.5rem)
- `px-4 py-3`: Padding horizontal/vertical
- `gap-3`: Gap between flex/grid items (0.75rem)
- `space-y-3`: Vertical spacing between children

### Flexbox
- `flex`: Display flex
- `flex-1`: Flex grow to fill space
- `flex-col`: Flex direction column
- `flex-shrink-0`: Prevent shrinking
- `items-center`: Align items center
- `items-start`: Align items start
- `justify-between`: Space between items
- `justify-end`: Justify content end

### Grid
- `grid grid-cols-1 md:grid-cols-3`: Responsive grid (1 col mobile, 3 cols desktop)
- `md:col-span-2`: Span 2 columns on medium screens

## Sizing

### Width
- `w-6 h-6`: 1.5rem × 1.5rem (icons)
- `w-10 h-10`: 2.5rem × 2.5rem (buttons)
- `w-16`: 4rem (collapsed sidebar)
- `w-64`: 16rem (expanded sidebar)
- `w-full`: 100% width
- `min-w-0`: Allow text truncation

### Height
- `h-full`: 100% height
- `min-h-screen`: Minimum 100vh
- `h-[calc(100vh-4rem)]`: Calculated height

## Positioning

### Position
- `relative`: Relative positioning (for absolute children)
- `absolute`: Absolute positioning
- `fixed`: Fixed positioning
- `sticky top-0`: Sticky at top
- `inset-0`: top/right/bottom/left all 0
- `top-1 right-1`: Positioned from top/right

### Z-Index
- `z-40`: Header z-index
- `z-50`: Panel/modal z-index

## Colors

### Background
- `bg-white`: White background
- `bg-gray-50`: Very light gray (#f9fafb)
- `bg-gray-100`: Light gray hover state
- `bg-gray-900`: Dark footer background
- `bg-primary-500`: Primary blue (#3b82f6)
- `bg-blue-100`: Active link background
- `bg-red-500`: Danger/badge background
- `bg-black bg-opacity-40`: Backdrop with transparency

### Text
- `text-gray-500`: Medium gray text
- `text-gray-900`: Dark text
- `text-white`: White text
- `text-blue-800`: Active link text
- `text-primary-600`: Primary color text

## Typography

### Size
- `text-xs`: 0.75rem
- `text-sm`: 0.875rem
- `text-base`: 1rem
- `text-lg`: 1.125rem
- `text-xl`: 1.25rem
- `text-2xl`: 1.5rem
- `text-4xl`: 2.25rem

### Weight & Style
- `font-medium`: 500 weight
- `font-semibold`: 600 weight
- `font-bold`: 700 weight

### Text Utilities
- `text-center`: Center text
- `truncate`: Text ellipsis (single line)
- `whitespace-nowrap`: No wrapping
- `overflow-hidden text-ellipsis`: Text truncation
- `break-words`: Break long words

## Borders

### Border
- `border`: 1px border
- `border-2`: 2px border
- `border-t`: Top border only
- `border-r`: Right border only
- `border-b`: Bottom border only
- `border-l-4`: Left border 4px
- `border-gray-200`: Light gray border
- `border-transparent`: Transparent border

### Border Radius
- `rounded-full`: Perfect circle
- `rounded-lg`: 0.5rem radius
- `rounded-xl`: 0.75rem radius
- `rounded-2xl`: 1rem radius (chat bubbles)

## Shadows
- `shadow-md`: Medium shadow
- `shadow-header`: Custom header shadow
- `shadow-panel`: Custom panel shadow
- `shadow-dropdown`: Custom dropdown shadow

## Interactive States

### Hover
- `hover:bg-gray-100`: Hover background
- `hover:text-gray-900`: Hover text color
- `hover:bg-primary-600`: Hover primary button

### Focus
- `focus:outline`: Show outline
- `focus:outline-2`: 2px outline
- `focus:outline-primary-500`: Primary color outline
- `focus:outline-offset-2`: Outline offset
- `focus:ring-2 focus:ring-primary-500`: Focus ring

### Disabled
- `disabled:opacity-50`: Reduced opacity
- `disabled:cursor-not-allowed`: Not-allowed cursor

### Active
- `.active` class: `bg-blue-100 text-blue-800` (NavLink)

## Transitions & Animations

### Transitions
- `transition-colors`: Transition color properties
- `transition-all duration-200`: All properties, 200ms
- `transition-all duration-300`: All properties, 300ms

### Animations
- `animate-spin`: Spinning loader
- `animate-fadeIn`: Custom fade-in (300ms)
- `animate-slideIn`: Custom slide-in (200ms)
- `animate-fade`: Custom fade highlight (1s)

## Responsive Design

### Breakpoints
- `md:`: Medium screens (768px+)
- `lg:`: Large screens (1024px+)

### Examples
- `hidden md:block`: Hidden mobile, visible desktop
- `grid-cols-1 md:grid-cols-3`: 1 col mobile, 3 cols desktop
- `w-full md:w-auto`: Full width mobile, auto desktop

## Utility Patterns

### Button
```
inline-flex items-center justify-center w-10 h-10 rounded-full 
bg-transparent text-gray-500 hover:bg-gray-100 hover:text-gray-900 
focus:outline focus:outline-2 focus:outline-primary-500
```

### Card
```
bg-white rounded-lg shadow-md border border-gray-200 p-6
```

### Nav Link (Inactive)
```
flex items-center gap-3 px-3 py-3 text-gray-500 rounded-lg 
hover:bg-gray-100 hover:text-gray-900
```

### Nav Link (Active)
```
flex items-center gap-3 px-3 py-3 rounded-lg active
```
(`.active` applies `bg-blue-100 text-blue-800`)

### Chat Bubble (Mine)
```
max-w-[70%] px-4 py-2 rounded-2xl bg-blue-500 text-white
```

### Chat Bubble (Theirs)
```
max-w-[70%] px-4 py-2 rounded-2xl bg-white border border-gray-200 text-gray-900
```

### Avatar
```
w-10 h-10 rounded-full
```

### Badge
```
absolute top-1 right-1 w-2 h-2 rounded-full bg-red-500
```

### Backdrop
```
fixed inset-0 bg-black bg-opacity-40 animate-fadeIn z-50
```

### Dropdown Menu
```
absolute right-0 top-full mt-1 w-56 bg-white rounded-lg shadow-dropdown py-1 z-50
```

### Loading Spinner
```
w-12 h-12 border-4 border-primary-500 border-t-transparent rounded-full animate-spin
```

## Custom Theme Extensions

### Colors (tailwind.config.js)
- `primary`: Blue scale (50-900)
- `gray`: Full gray scale (50-900)
- `danger`: Red scale (50-900)

### Shadows (tailwind.config.js)
- `header`: '0 1px 2px 0 rgba(0, 0, 0, 0.05)'
- `panel`: '0 4px 12px rgba(0, 0, 0, 0.15)'
- `dropdown`: '0 2px 8px rgba(0, 0, 0, 0.15)'

### Animations (tailwind.config.js)
- `fadeIn`: Opacity 0 → 1 (300ms)
- `slideIn`: TranslateX 100% → 0 (200ms)
- `fade`: Opacity 1 → 0 (1s)

## VS Code IntelliSense

To get Tailwind CSS IntelliSense in VS Code:
1. Install "Tailwind CSS IntelliSense" extension
2. Add to `.vscode/settings.json`:
```json
{
  "tailwindCSS.includeLanguages": {
    "razor": "html",
    "cshtml": "html"
  },
  "editor.quickSuggestions": {
    "strings": true
  }
}
```
